namespace PlayersAndMonsters.Core
{
    using System;
    using System.Text;
    using Contracts;
    using PlayersAndMonsters.Common;
    using PlayersAndMonsters.Core.Factories;
    using PlayersAndMonsters.Core.Factories.Contracts;
    using PlayersAndMonsters.Models.BattleFields;
    using PlayersAndMonsters.Models.BattleFields.Contracts;
    using PlayersAndMonsters.Models.Cards.Contracts;
    using PlayersAndMonsters.Models.Players.Contracts;
    using PlayersAndMonsters.Repositories;
    using PlayersAndMonsters.Repositories.Contracts;

    public class ManagerController : IManagerController
    {
        private readonly ICardFactory cardFactory;
        private readonly IPlayerFactory playerFactory;

        private readonly ICardRepository cardRepository;
        private readonly IPlayerRepository playerRepository;
        private readonly IBattleField battleField;
        public ManagerController()
        {
            this.cardFactory = new CardFactory();
            this.playerFactory = new PlayerFactory();

            this.cardRepository = new CardRepository();
            this.playerRepository = new PlayerRepository();

            this.battleField = new BattleField();

        }

        public string AddPlayer(string type, string username)
        {
            var player = playerFactory.CreatePlayer(type, username);

            this.playerRepository.Add(player);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayer, type, username);
        }

        public string AddCard(string type, string name)
        {
            var card = cardFactory.CreateCard(type, name);

            this.cardRepository.Add(card);

            return string.Format(ConstantMessages.SuccessfullyAddedCard, type, name);
        }

        public string AddPlayerCard(string username, string cardName)
        {
            IPlayer currentPlayer = this.playerRepository.Find(username);
            ICard currentCard = this.cardRepository.Find(cardName);

            currentPlayer.CardRepository.Add(currentCard);

            return string.Format(ConstantMessages.SuccessfullyAddedPlayerWithCards, cardName, username);
        }

        public string Fight(string attackUser, string enemyUser)
        {
            IPlayer attackPlayer = this.playerRepository.Find(attackUser);
            IPlayer enemyPlayer = this.playerRepository.Find(enemyUser);

            this.battleField.Fight(attackPlayer, enemyPlayer);

            return string.Format(ConstantMessages.FightInfo, attackPlayer.Health, enemyPlayer.Health);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var player in this.playerRepository.Players)
            {
                sb.AppendLine(string.Format(ConstantMessages.PlayerReportInfo,
                    player.Username,
                    player.Health,
                    player.CardRepository.Cards.Count));

                foreach (var cards in player.CardRepository.Cards)
                {
                    sb.AppendLine(string.Format(ConstantMessages.CardReportInfo,
                    cards.Name,
                    cards.DamagePoints));
                }
                sb.AppendLine(string.Format(ConstantMessages.DefaultReportSeparator));
            }

            return sb.ToString().Trim();
        }
    }
}
