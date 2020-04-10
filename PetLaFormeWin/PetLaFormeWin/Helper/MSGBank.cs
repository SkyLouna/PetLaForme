using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetLaFormeWin.Helper
{
    public static class MSGBank
    {
        public const String ERROR_TITLE = "ERREUR";

        public const String ERROR_RETRY = "Veuillez rééssayer ultérieurement !";
        public const String ERROR_UNKNOWN = "Une erreur inconnue est survenue . \n" + ERROR_RETRY;
        public const String ERROR_NO_SERVER = "Aucun serveur n'est actuellement disponible.\n" + ERROR_RETRY;

        public const String ERROR_WRONG_EMAIL = "Adresse E-Mail non valide !";
        public const String ERROR_NOT_SAME_PASSWORD = "Les deux mots de passe ne sont pas identiques !";

        public const String ERROR_UNKNOWN_USER = "Cet nom d'utilisateur est invalide ou n'existe pas !";

        public const String ERROR_FILL_ALL_FIELDS = "Vous devez remplir tous les champs !";

        public const String ERROR_SHARE_YOURSELF = "Vous ne pouvez pas partager un animal avec vous-même.";

    }
}
