using Enums;

namespace Models
{
    public class PotionsInformationClass
    {
        public int PotionID { get; set; }
        public string Title { get; set; }
        public Effect Effect { get; set; }
        public string Description { get; set; }

        public string GetShortInfo()
        {
            return $"{PotionID}. {Title}";
        }

        public string GetFullInfo()
        {
            var effect = GetEffect();
            return $"Id: {PotionID}\nНазвание:{Title}\nЭффект: {effect}\n\nОписание: {Description}";
        }

        private string GetEffect()
        {
            var effect = string.Empty;

            if(Effect == Effect.Positive)
            {
                effect = "Позитивный";
            }
            else if(Effect == Effect.Negative)
            {
                effect = "Негативный";
            }
            else
            {
                effect = "Нейтральный";
            }

            return effect;
        }
    }
}