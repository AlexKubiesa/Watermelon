using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using System.Drawing;
using Watermelon.Gameplay;

namespace Watermelon.ResourceManagement
{
    static class CardImageHandler
    {
        public static Image FaceDownImage
        {
            get
            {
                if (!_initialised)
                {
                    Initialise();
                }
                return _faceDownImage;
            }
        }

        private static bool _initialised;

        private static Image _faceDownImage;

        private static List<Tuple<CardRank, CardSuit, Image>>
            _cardImages = new List<Tuple<CardRank, CardSuit, Image>>();

        public static void Initialise()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Stream FaceDownStream = assembly.GetManifestResourceStream("Watermelon.Resources.face_down.png");
            _faceDownImage = Image.FromStream(FaceDownStream);

            foreach (CardRank rank in Enum.GetValues(typeof(CardRank)).Cast<CardRank>())
            {
                foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)).Cast<CardSuit>())
                {
                    string rankName = Enum.GetName(typeof(CardRank), rank).ToLower();
                    string suitName = Enum.GetName(typeof(CardSuit), suit).ToLower();

                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("Watermelon.Resources.");
                    stringBuilder.Append(rankName);
                    stringBuilder.Append("_of_");
                    stringBuilder.Append(suitName);
                    stringBuilder.Append(".png");

                    Stream cardImageStream = assembly.GetManifestResourceStream(stringBuilder.ToString());
                    Image cardImage = Image.FromStream(cardImageStream);

                    _cardImages.Add(Tuple.Create(rank, suit, cardImage));
                }
            }

            _initialised = true;
        }

        public static Image GetCardImage(CardRank rank, CardSuit suit)
        {
            if (!_initialised)
            {
                Initialise();
            }
            var imageTuple = _cardImages.FirstOrDefault(x => (x.Item1 == rank && x.Item2 == suit));
            if (imageTuple == null)
            {
                throw new InvalidOperationException("No image stored for given card rank and suit.");
            }
            else
            {
                return imageTuple.Item3;
            }
        }

        public static Image GetCardImage(Card card)
        {
            return GetCardImage(card.Rank, card.Suit);
        }
    }
}
