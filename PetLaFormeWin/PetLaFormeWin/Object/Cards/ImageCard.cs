using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetLaFormeWin.Object.Cards
{
    public abstract class ImageCard : GraphicCard
    {

        Image image;                            //image file
            
        PictureBox pictureBox;                  //picture box

        public ImageCard(string title,Image image, int width, int height, Action actionOnClick = null, Action actionOnDoubleClick = null) : base(title, width, height, actionOnClick, actionOnDoubleClick)
        {
            this.image = image;

            //init new picture  box
            pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

            //add picture box to container
            GbBoxContainer.Controls.Add(pictureBox);

            //add event handlers
            pictureBox.Click += new EventHandler(ActionClick);
            pictureBox.DoubleClick += new EventHandler(ActionDoubleClick);

        }

        public void Dispose()
        {
            //dispose contains
            LblTitle.Dispose();
            PictureBox.Dispose();
            GbBoxContainer.Dispose();
        }

        public PictureBox PictureBox { get => pictureBox; set => pictureBox = value; }
    }
}
