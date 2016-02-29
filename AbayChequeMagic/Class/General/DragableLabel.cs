using System;
using System.Windows.Forms;
using System.Drawing;

namespace AbayChequeMagic
{
	public class DragLabel
    {
        #region About DragLabel Class

        /************** Written by Rinesh PK on 18-09-2012 ******************/
        //                                                                  //
        /////// Can be used for Drag and Resize windows form controls ////////
        //                                                                  //
        //        1: use the function WireControls() to add to a control    //
        //        2: use thr Remove function to remove from a control       //
        //                                                                  //
        //                                                                  //
        //                                                                  //
        //////////////////////////////////////////////////////////////////////

        #endregion
        #region Private Constants and Variables

	    private const int intBoxSize = 5;
	    private Color BoxColor = Color.Lime;
        private Control ctrlControl;
	    private Label[] lbl = new Label[8];
	    private int intStartl;
        private int intStartt;
	    private int intStartw;
        private int intStarth;
	    private int intStartx;
        private int intStarty;
	    private bool isDragging;
	    private	Cursor[] arrArrow = new Cursor[] {Cursors.SizeNWSE, Cursors.SizeNS,
			    Cursors.SizeNESW, Cursors.SizeWE, Cursors.SizeNWSE, Cursors.SizeNS,
			    Cursors.SizeNESW, Cursors.SizeWE};
	    private Cursor oldCursor;
	    private const int inMinSize = 20;

        #endregion

        #region

        //
	    // Constructor creates 8 sizing handles & wires mouse events
	    // to each that implement sizing functions
	    //
	    public DragLabel() {
		    for (int i = 0; i<8; i++) 
            {
			    lbl[i] = new Label();
			    lbl[i].TabIndex = i;
			    lbl[i].FlatStyle = 0 ;
			    lbl[i].BorderStyle = BorderStyle.FixedSingle;
			    lbl[i].BackColor = BoxColor;
			    lbl[i].Cursor = arrArrow[i];
			    lbl[i].Text = "";
			    lbl[i].BringToFront();
			    lbl[i].MouseDown += new MouseEventHandler(this.lbl_MouseDown);
			    lbl[i].MouseMove += new MouseEventHandler(this.lbl_MouseMove);
			    lbl[i].MouseUp += new MouseEventHandler(this.lbl_MouseUp);
		    }
        }
        #endregion

        #region Public Methods
        //
	    // Wires a Click event handler to the passed Control
        // that attaches a draghandle to the control when it is clicked
	    //
	    public void WireControl(Control ctl) 
        {
		    ctl.Click += new EventHandler(this.SelectControl);
        }

        #endregion

        #region Private Methods
        //
	    // Attaches a draghandle to the sender Control
	    //
	    private void SelectControl(object sender, EventArgs e) {

		    if (ctrlControl is Control) 
            {
			    ctrlControl.Cursor = oldCursor;

			    //Remove event any pre-existing event handlers appended by this class
			    ctrlControl.MouseDown -= new MouseEventHandler(this.ctl_MouseDown);
			    ctrlControl.MouseMove -= new MouseEventHandler(this.ctl_MouseMove);
			    ctrlControl.MouseUp -= new MouseEventHandler(this.ctl_MouseUp);

			    ctrlControl = null;
		    }

		    ctrlControl = (Control)sender;
		    //Add event handlers for moving the selected control around
		    ctrlControl.MouseDown += new MouseEventHandler(this.ctl_MouseDown);
		    ctrlControl.MouseMove += new MouseEventHandler(this.ctl_MouseMove);
		    ctrlControl.MouseUp += new MouseEventHandler(this.ctl_MouseUp);

		    //Add sizing handles to Control's container (Form or Panel)
		    for (int i = 0; i<8; i++) 
            {
			    ctrlControl.Parent.Controls.Add(lbl[i]);
			    lbl[i].BringToFront();
		    }

		    //Position sizing handles around Control
		    MoveHandles();

		    //Display sizing handles
		    ShowHandles();

		    oldCursor = ctrlControl.Cursor;
		    ctrlControl.Cursor = Cursors.SizeAll;

       }

	    public void Remove() 
        {
		    HideHandles();
		    ctrlControl.Cursor = oldCursor;
	    }

	    private void ShowHandles() 
        {
		    if (ctrlControl !=null) 
            {
			    for (int i = 0; i<8; i++) 
                {
				    lbl[i].Visible = true;
			    }
		    }
	    }

	    private void HideHandles() 
        {
            for (int i = 0; i<8; i++) 
            {
		       lbl[i].Visible = false;
		    }
	    }

	    private void MoveHandles() 
        {
		    int sX = ctrlControl.Left - intBoxSize;
		    int sY = ctrlControl.Top - intBoxSize;
		    int sW = ctrlControl.Width + intBoxSize;
		    int sH = ctrlControl.Height + intBoxSize;
		    int hB = intBoxSize / 2;
		    int[] arrPosX = new int[] {sX+hB, sX + sW / 2, sX + sW-hB, sX + sW-hB,
			    sX + sW-hB, sX + sW / 2, sX+hB, sX+hB};
		    int[] arrPosY = new int[] {sY+hB, sY+hB, sY+hB, sY + sH / 2, sY + sH-hB,
			    sY + sH-hB, sY + sH-hB, sY + sH / 2};
		    for(int i=0; i<8; i++)
			    lbl[i].SetBounds(arrPosX[i], arrPosY[i], intBoxSize, intBoxSize);
        }
        #endregion
    
        #region Events

        /////////////////////////////////////////////////////////////////
        // MOUSE EVENTS THAT IMPLEMENT SIZING OF THE PICKED CONTROL
        /////////////////////////////////////////////////////////////////
        //
	    // Store control position and size when mouse button pushed over
	    // any sizing handle
	    //
	    private void lbl_MouseDown(object sender, MouseEventArgs e) 
        {
            isDragging = true;
		    intStartl = ctrlControl.Left;
		    intStartt = ctrlControl.Top;
            intStartw = ctrlControl.Width;
            intStarth = ctrlControl.Height;
		    HideHandles();
	    }

	    //
	    // Size the picked control in accordance with sizing handle being dragged
	    //	0   1   2
	    //  7       3
	    //  6   5   4
	    //
        private void lbl_MouseMove(object sender, MouseEventArgs e) 
        {
            int l = ctrlControl.Left;
            int w = ctrlControl.Width;
            int t = ctrlControl.Top;
            int h = ctrlControl.Height;
		    if (isDragging) {
		    switch (((Label)sender).TabIndex) 
            {
			    case 0: // isDragging top-left sizing box
				    l = intStartl + e.X < intStartl + intStartw - inMinSize ? intStartl + e.X : intStartl + intStartw - inMinSize;
				    t = intStartt + e.Y < intStartt + intStarth - inMinSize ? intStartt + e.Y : intStartt + intStarth - inMinSize;
				    w = intStartl + intStartw - ctrlControl.Left;
				    h = intStartt + intStarth - ctrlControl.Top;
				    break;
			    case 1: // isDragging top-center sizing box
				    t = intStartt + e.Y < intStartt + intStarth - inMinSize ? intStartt + e.Y : intStartt + intStarth - inMinSize;
				    h = intStartt + intStarth - ctrlControl.Top;
				    break;
			    case 2: // isDragging top-right sizing box
				    w = intStartw + e.X > inMinSize ? intStartw + e.X : inMinSize;
				    t = intStartt + e.Y < intStartt + intStarth - inMinSize ? intStartt + e.Y : intStartt + intStarth - inMinSize;
				    h = intStartt + intStarth - ctrlControl.Top;
				    break;
			    case 3: // isDragging right-middle sizing box
				    w = intStartw + e.X > inMinSize ? intStartw + e.X : inMinSize;
				    break;
			    case 4: // isDragging right-bottom sizing box
				    w = intStartw + e.X > inMinSize ? intStartw + e.X : inMinSize;
				    h = intStarth + e.Y > inMinSize ? intStarth + e.Y : inMinSize;
				    break;
			    case 5: // isDragging center-bottom sizing box
				    h = intStarth + e.Y > inMinSize ? intStarth + e.Y : inMinSize;
				    break;
			    case 6: // isDragging left-bottom sizing box
				    l = intStartl + e.X < intStartl + intStartw - inMinSize ? intStartl + e.X : intStartl + intStartw - inMinSize;
				    w = intStartl + intStartw - ctrlControl.Left;
				    h = intStarth + e.Y > inMinSize ? intStarth + e.Y : inMinSize;
				    break;
			    case 7: // isDragging left-middle sizing box
				    l = intStartl + e.X < intStartl + intStartw - inMinSize ? intStartl + e.X : intStartl + intStartw - inMinSize;
                    w = intStartl + intStartw - ctrlControl.Left;
				    break;
		       }
            l =(l<0)?0:l;
            t =(t<0)?0:t;
            ctrlControl.SetBounds(l,t,w,h);
            }
        }

	    //
	    // Display sizing handles around picked control once sizing has completed
	    //
	    private void lbl_MouseUp(object sender, MouseEventArgs e) {
            isDragging = false;
            MoveHandles();
            ShowHandles();
	    }

	    /////////////////////////////////////////////////////////////////
	    // MOUSE EVENTS THAT MOVE THE PICKED CONTROL AROUND THE FORM
	    /////////////////////////////////////////////////////////////////

	    //
	    // Get mouse pointer starting position on mouse down and hide sizing handles
	    //
	    private void ctl_MouseDown(object sender, MouseEventArgs e) 
        {
            isDragging = true;
		    intStartx = e.X;
		    intStarty = e.Y;
		    HideHandles();
	    }

	    //
	    // Reposition the dragged control
	    //
	    private void ctl_MouseMove(object sender, MouseEventArgs e) 
        {
            if (isDragging) 
            {
			    int l =  ctrlControl.Left + e.X - intStartx;
			    int t = ctrlControl.Top + e.Y - intStarty;
                int w = ctrlControl.Width;
                int h = ctrlControl.Height;
                l =(l<0)?0:((l+w > ctrlControl.Parent.ClientRectangle.Width)?
                  ctrlControl.Parent.ClientRectangle.Width-w:l);
                t =(t<0)?0:((t+h> ctrlControl.Parent.ClientRectangle.Height)?
                ctrlControl.Parent.ClientRectangle.Height-h:t);
                ctrlControl.Left = l;
                ctrlControl.Top = t;
		    }
	    }

	    //
	    // Display sizing handles around picked control once isDragging has completed
	    //
	    private void ctl_MouseUp(object sender, MouseEventArgs e) 
        {
		    isDragging = false;
		    MoveHandles();
		    ShowHandles();
        }
        #endregion
}
}

