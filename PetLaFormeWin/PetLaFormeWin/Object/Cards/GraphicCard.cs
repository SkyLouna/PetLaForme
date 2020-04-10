using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetLaFormeWin.Object.Cards
{
    public abstract class GraphicCard
    {

        String title;                               //title of the card
        int width;                                  //x size 
        int height;                                 //y size

        Action actionOnClick;                       //action on simple click
        Action actionOnDoubleClick;                 //action on double click

        ColoredGroupBox gbBoxContainer;             //Card container box
        Label lblTitle;                             //card title

        public GraphicCard(String title, int width, int height, Action actionOnClick = null, Action actionOnDoubleClick = null)
        {
            //init local properties
            this.title = title;
            this.width = width;
            this.height = height;
            this.actionOnClick = actionOnClick;
            this.actionOnDoubleClick = actionOnDoubleClick;

            //init new label
            lblTitle = new Label();

            //init new colored group box
            gbBoxContainer = new ColoredGroupBox();
            gbBoxContainer.Size = new Size(width, height);
            gbBoxContainer.BorderColor = Color.Black;
            gbBoxContainer.Controls.Add(lblTitle);

            //add event handlers
            gbBoxContainer.Click += new EventHandler(ActionClick);
            gbBoxContainer.DoubleClick += new EventHandler(ActionDoubleClick);  

            lblTitle.Click += new EventHandler(ActionClick);
            lblTitle.DoubleClick += new EventHandler(ActionDoubleClick);

        }

        public void SetLocation(int x, int y, Control control)
        {
            //set location in a control
            gbBoxContainer.Location = new Point(x, y);

            control.Controls.Add(gbBoxContainer);
            
        }

        public void ActionClick(object sender, EventArgs args)
        {
            //if there is an action
            if(actionOnClick != null)
                actionOnClick.Invoke();
        }

        public void ActionDoubleClick(object sender, EventArgs args)
        {
            //if there is an action
            if (actionOnDoubleClick != null)
                actionOnDoubleClick.Invoke();
        }

        public abstract void DrawForm();

        public ColoredGroupBox GbBoxContainer { get => gbBoxContainer; set => gbBoxContainer = value; }
        public Label LblTitle { get => lblTitle; set => lblTitle = value; }
        public Action ActionOnClick { get => actionOnClick; set => actionOnClick = value; }
        public Action ActionOnDoubleClick { get => actionOnDoubleClick; set => actionOnDoubleClick = value; }
    }

    /// <summary>
    /// SOURCE: https://social.msdn.microsoft.com/Forums/windows/en-US/60767912-6ea4-4ff6-acb5-44002bd94e82/how-to-change-border-color-of-groupbox-in-cnet
    /// COMMENTS: Trana Valentin
    /// </summary>
    public class ColoredGroupBox : GroupBox
    {
        private Color _borderColor = Color.Black;

        public Color BorderColor
        {
            get { return this._borderColor; }
            set { this._borderColor = value; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //get the text size in groupbox top
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);

            //draw the border rect of the group box
            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y = (borderRect.Y + (tSize.Height / 2));
            borderRect.Height = (borderRect.Height - (tSize.Height / 2));

            //draw rect border with control paint
            ControlPaint.DrawBorder(e.Graphics, borderRect, this._borderColor, ButtonBorderStyle.Solid);

            //get text rect
            Rectangle textRect = e.ClipRectangle;
            textRect.X = (textRect.X + 6);
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;

            //fill rect with back color and draw groupbox text
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
        }
    }

}
