using PLFAPI.Object.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PLFServer.Helper
{
    public static class MailHelper
    {

        public static void SendRegisterConfirmationMail(PLFUser user, String userSecretKey)
        {
            new Thread(() =>
            {
                //send mail
                Program.mailManager.SendMail(user.UserEMail, "PET LA FORME - Inscription",
                    $"Bonjour {user.UserName}! Merci de vous être inscrit sur la plateforme PetLaForme. Voici votre code d'activation de votre compte: "
                    + $"{userSecretKey}. Merci de la rentrer dans votre application pour pouvoir activer votre compte ! Bonne journée !");
            }).Start();
           
        }

    }
}
