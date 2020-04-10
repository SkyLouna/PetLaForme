using System;
using System.Drawing;

namespace PetLaFormeWin.Object.Cards
{
    public class AddCard : ImageCard
    {

        public AddCard(Action actionOnClick = null, Action actionOnDoubleClick = null) 
            : base("Nouveau", new Bitmap(Properties.Resources.plus_button), 180, 180, actionOnClick, actionOnDoubleClick)
        {

        }

        public override void DrawForm()
        {
            //set label properties
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            LblTitle.Location = new Point(6, 13);
            LblTitle.Size = new Size(160, 29);
            LblTitle.TabIndex = 1;
            LblTitle.Text = "Nouveau";

            //set picture box properties
            PictureBox.Location = new Point(22, 42);
            PictureBox.Size = new Size(136, 136);
            PictureBox.TabIndex = 2;
            PictureBox.TabStop = false;
            PictureBox.Image = new Bitmap(Properties.Resources.plus_button);

            GbBoxContainer.Text = "Ajout";
        }

    }
}
