using PLFAPI.Helper;
using PLFAPI.Object.Pet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLaFormeWin.Object.Cards
{
    public class PetCard : ImageCard
    {
        PLFPet pet;                     //pet card

        public PetCard(PLFPet pet, Action actionOnClick = null, Action actionOnDoubleClick = null) 
            : base(pet.PetName, new Bitmap(Properties.Resources.bone), 180, 180, actionOnClick, actionOnDoubleClick)
        {
            this.pet = pet;
        }

        public override void DrawForm()
        {
            //set label properties
            LblTitle.AutoSize = true;
            LblTitle.Font = new Font("Arial Narrow", 18F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            LblTitle.Location = new Point(6, 14);
            LblTitle.Name = "lblTitle" + pet.PetID;
            LblTitle.Size = new Size(160, 29);
            LblTitle.TabIndex = 1;
            LblTitle.Text = pet.PetName;
            LblTitle.SendToBack();

            //set picture box properties
            PictureBox.Location = new Point(22, 42);
            PictureBox.Name = "pictureBox" + pet.PetID;
            PictureBox.Size = new Size(136, 136);
            PictureBox.TabIndex = 2;
            PictureBox.TabStop = false;
            PictureBox.Image = PetHelper.GetImageForPetType(pet.PetType);

            //set the box text
            if (pet.Shared)
                GbBoxContainer.Text = "Partagé";
            else
                GbBoxContainer.Text = "Personnel ";
        }

    }
}
