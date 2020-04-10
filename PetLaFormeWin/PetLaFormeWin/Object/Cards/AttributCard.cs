using PLFAPI.Helper;
using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLaFormeWin.Object.Cards
{
    public class AttributCard : ImageCard
    {
        PetAttribute petAttribute;                  //card attribute

        public AttributCard(PetAttribute petAttribute, Action actionOnClick = null, Action actionOnDoubleClick = null) 
            : base(petAttribute.AttributeTitle, new Bitmap(Properties.Resources.bone), 180, 180, actionOnClick, actionOnDoubleClick)
        {
            this.petAttribute = petAttribute;

        }

        public override void DrawForm()
        {
            //set label properties
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            LblTitle.Location = new Point(6, 8);
            LblTitle.Name = "lblTitle" + petAttribute.AttributeTitle;
            LblTitle.Size = new Size(150, 29);
            LblTitle.TabIndex = 1;
            LblTitle.Text = petAttribute.AttributeTitle;
            LblTitle.SendToBack();

            //set picture box properties
            PictureBox.Location = new Point(20, 38);
            PictureBox.Name = "pictureBox" + petAttribute.AttributeTitle;
            PictureBox.Size = new Size(140, 140);
            PictureBox.TabIndex = 2;
            PictureBox.TabStop = false;
            PictureBox.Image = PetHelper.GetImageForPetAttributeType(this.petAttribute.PetAttributeType);
        }
    }
}
