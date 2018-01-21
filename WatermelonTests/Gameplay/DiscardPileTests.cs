using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Watermelon.Gameplay;

namespace WatermelonTests.Gameplay
{
    [TestFixture]
    public class DiscardPileTests
    {
        private DiscardPile discardPile;

        [SetUp]
        protected void SetUp()
        {
            discardPile = new DiscardPile();
        }

        [Test]
        public void PlayCard_ShouldBurn_WhenTenIsPlayed()
        {
            discardPile.PlayCard(new Card(CardRank.Two, CardSuit.Clubs), out _);
            discardPile.PlayCard(new Card(CardRank.Ten, CardSuit.Diamonds), out bool burn);
            Assert.IsTrue(burn);
            Assert.IsEmpty(discardPile.OrientedCards);
        }

        [Test]
        public void PlayCard_ShouldBurn_WhenFourthConsecutiveCardOfSameRankIsPlayed()
        {
            discardPile.PlayCard(new Card(CardRank.Two, CardSuit.Clubs), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Diamonds), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Clubs), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Hearts), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Spades), out bool burn);
            Assert.IsTrue(burn);
            Assert.IsEmpty(discardPile.OrientedCards);
        }

        [Test]
        public void PlayCard_ShouldNotBurn_WhenCardsAreNotConsecutive()
        {
            discardPile.PlayCard(new Card(CardRank.Two, CardSuit.Clubs), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Diamonds), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Clubs), out _);
            discardPile.PlayCard(new Card(CardRank.Three, CardSuit.Spades), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Hearts), out _);
            discardPile.PlayCard(new Card(CardRank.Eight, CardSuit.Spades), out bool burn);
            Assert.IsFalse(burn);
            Assert.IsNotEmpty(discardPile.OrientedCards);
        }
    }
}
