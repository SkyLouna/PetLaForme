using PLFAPI.Object.Pet;
using PLFAPI.Object.Pet.Attribute;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLFAPI.Helper
{
    public static class PetHelper
    {

        public static Image GetImageForPetType(PetType petType)
        {
            Image petImage = Properties.Resources.bone; 
            switch (petType)
            {
                case PetType.OTHER:
                    petImage = Properties.Resources.bone;
                    break;
                case PetType.BAT:
                    petImage = Properties.Resources.bat;
                    break;
                case PetType.BEAR:
                    petImage = Properties.Resources.bear;
                    break;
                case PetType.BUTTERFLY:
                    petImage = Properties.Resources.butterfly;
                    break;
                case PetType.CAT:
                    petImage = Properties.Resources.cat;
                    break;
                case PetType.CHIPMUNK:
                    petImage = Properties.Resources.chipmunk;
                    break;
                case PetType.CRICKET:
                    petImage = Properties.Resources.cricket;
                    break;
                case PetType.CROCODILE:
                    petImage = Properties.Resources.crocodile;
                    break;
                case PetType.DOG:
                    petImage = Properties.Resources.dog;
                    break;
                case PetType.DUCK:
                    petImage = Properties.Resources.duck;
                    break;
                case PetType.FISH:
                    petImage = Properties.Resources.fish;
                    break;
                case PetType.FOX:
                    petImage = Properties.Resources.fox;
                    break;
                case PetType.FROG:
                    petImage = Properties.Resources.frog;
                    break;
                case PetType.GIRAFFE:
                    petImage = Properties.Resources.giraffe;
                    break;
                case PetType.HAMSTER:
                    petImage = Properties.Resources.hamster;
                    break;
                case PetType.HEDGEHOG:
                    petImage = Properties.Resources.hedgehog;
                    break;
                case PetType.HEN:
                    petImage = Properties.Resources.hen;
                    break;
                case PetType.HORSE:
                    petImage = Properties.Resources.horse;
                    break;
                case PetType.KOALA:
                    petImage = Properties.Resources.koala;
                    break;
                case PetType.LION:
                    petImage = Properties.Resources.lion;
                    break;
                case PetType.LIZARD:
                    petImage = Properties.Resources.lizard;
                    break;
                case PetType.MONKEY:
                    petImage = Properties.Resources.monkey;
                    break;
                case PetType.MOUSE:
                    petImage = Properties.Resources.mouse;
                    break;
                case PetType.OWL:
                    petImage = Properties.Resources.owl;
                    break;
                case PetType.PANDA:
                    petImage = Properties.Resources.panda;
                    break;
                case PetType.PENGUIN:
                    petImage = Properties.Resources.penguin;
                    break;
                case PetType.PIG:
                    petImage = Properties.Resources.pig;
                    break;
                case PetType.RABBIT:
                    petImage = Properties.Resources.rabbit;
                    break;
                case PetType.SNAIL:
                    petImage = Properties.Resources.snail;
                    break;
                case PetType.SNAKE:
                    petImage = Properties.Resources.snake;
                    break;
                case PetType.SPIDER:
                    petImage = Properties.Resources.spider;
                    break;
                case PetType.TIGER:
                    petImage = Properties.Resources.tiger;
                    break;
                case PetType.TURTLE:
                    petImage = Properties.Resources.turtle;
                    break;
                case PetType.WOLF:
                    petImage = Properties.Resources.wolf;
                    break;
            }

            return petImage;
        }

        public static Image GetImageForPetAttributeType(PetAttributeType petAttributeType)
        {
            Image attributeImage = Properties.Resources.bone;

            switch (petAttributeType)
            {
                case PetAttributeType.OTHER:
                    attributeImage = Properties.Resources.bone;
                    break;
                case PetAttributeType.SEXE:
                    attributeImage = Properties.Resources.gender;
                    break;
                case PetAttributeType.WEIGHT:
                    attributeImage = Properties.Resources.weight;
                    break;
                case PetAttributeType.BIRTHDAY:
                    attributeImage = Properties.Resources.birthday;
                    break;
                case PetAttributeType.DEATHDAY:
                    attributeImage = Properties.Resources.deathday;
                    break;
                case PetAttributeType.FOOD:
                    attributeImage = Properties.Resources.food;
                    break;
                case PetAttributeType.DRUG:
                    attributeImage = Properties.Resources.drug;
                    break;
                case PetAttributeType.VETERINARY:
                    attributeImage = Properties.Resources.veterinary;
                    break;
                case PetAttributeType.WALKING:
                    attributeImage = Properties.Resources.walking;
                    break;
                case PetAttributeType.WASHING:
                    attributeImage = Properties.Resources.washing;
                    break;
                case PetAttributeType.COMPETITION:
                    attributeImage = Properties.Resources.competition;
                    break;
            }

            return attributeImage;
        }

        public static List<PetAttribute> GetDefaultAttributs()
        {

            const string defaultPrefix = "DEF -> ";

            List<PetAttribute> attributList = new List<PetAttribute>();

            attributList.Add(new PetAttribute(PetAttributeType.BIRTHDAY, defaultPrefix + DateTime.Now.ToShortDateString(), "Anniversaire de votre familier"));
            attributList.Add(new PetAttribute(PetAttributeType.SEXE, defaultPrefix + "Genre", "Genre de votre familier"));
            attributList.Add(new PetAttribute(PetAttributeType.WEIGHT, defaultPrefix + "3KG", "Poids de votre familier"));
            attributList.Add(new PetAttribute(PetAttributeType.WASHING, defaultPrefix + "Bains", "Deux bains par semaine"));
            attributList.Add(new PetAttribute(PetAttributeType.FOOD, defaultPrefix + "Repas", "Mange uniquement du .. provenant de sa gamelle"));
            attributList.Add(new PetAttribute(PetAttributeType.COMPETITION, defaultPrefix + "1st place", "Première place au concours de la pattoune et de la nageoire"));
            attributList.Add(new PetAttribute(PetAttributeType.VETERINARY, defaultPrefix + "Rendez-vous", "Rendez vous chez le veterinaire demain."));
            attributList.Add(new PetAttribute(PetAttributeType.WALKING, defaultPrefix + "Balades", "Balades deux fois par jour"));

            return attributList;
        }
    }
}