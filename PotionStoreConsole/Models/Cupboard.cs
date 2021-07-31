using System.Collections.Generic;
using System.Linq;
using Enums;

namespace Models
{
    public class Cupboard
    {
        public int Id { get; set; }
        public List<PotionsInformationClass> Potions { get; set; }

        public Cupboard()
        {
            Potions = SetPotions();
        }

        public void AddNewPotion(PotionsInformationClass potion)
        {
            if (potion != null)
            {
                Potions.Add(potion);
            }
            else
            {
                throw new System.Exception("Ошибка зелья.");
            }
        }

        public PotionsInformationClass GetPotionById(int potionId)
        {
            var potion = Potions.FirstOrDefault(p => p.PotionID == potionId);

            if (potion != null)
            {
                return potion;
            }
            throw new System.Exception("Зелье не найдено.");
        }

        public void DeletePotionById(int potionId)
        {
            var potion = GetPotionById(potionId);
            Potions.Remove(potion);
        }

        public void EditPotion(int potionId, string newTitle, string newEffect, string newDescription)
        {
            var potion = GetPotionById(potionId);
            if(string.IsNullOrWhiteSpace(newTitle) == false && newTitle.Length <= 50)
            {
                potion.Title = newTitle;
            }
            else if (newTitle.Length > 50)
            {
                throw new System.Exception("Длина названия не должна превышать 50 символов.");
            }
            if(string.IsNullOrWhiteSpace(newEffect) == false)
            {
                Effect effect = GetNewEffect(newEffect);
                potion.Effect = effect;
            }
            if(string.IsNullOrWhiteSpace(newDescription) == false && newDescription.Length <= 1000)
            {
                potion.Description = newDescription;
            }
            else if (newTitle.Length > 1000)
            {
                throw new System.Exception("Длина названия не должна превышать 1000 символов. Отправляйтесь в ад.");
            }
        }
        private Effect GetNewEffect(string NewEffect)
        {
            if (NewEffect == "п")
            {
                return Effect.Positive;
            }
            else if (NewEffect == "о")
            {
                return Effect.Negative;
            }
            else if (NewEffect == "н")
            {
                return Effect.Neutral;
            }
            else
            {
                throw new System.Exception("Невозможный эффект.");
            }
        }
        private List<PotionsInformationClass> SetPotions()
        {
            List<PotionsInformationClass> potions = new List<PotionsInformationClass>()
            {
                new PotionsInformationClass()
                {
                    PotionID = 0,
                    Title = "Целебное Зелье",
                    Effect = Effect.Positive,
                    Description = "Это зелье излечивает любые раны.",
                },
                new PotionsInformationClass()
                {
                    PotionID = 1,
                    Title = "Гадкое Зелье",
                    Effect = Effect.Negative,
                    Description = "Вызывает несварение желудка. Доза больше 200 мл может привести к смерти."
                },
                new PotionsInformationClass()
                {
                    PotionID = 2,
                    Title = "Приворотное Зелье",
                    Effect = Effect.Neutral,
                    Description = "Добавьте в зелье человеческий волос и человек, выпивший получившийся напиток, влюбится в обладателя волоса. Желательно класть волосы ОДНОГО человека и не того же, кто пьет зелье. Несоблюдение инструкции может привести к непредсказуемым результатам, но если вас это не пугает - веселитесь ;p.",
                },
                new PotionsInformationClass()
                {
                    PotionID = 3,
                    Title = "Зелье Молодости",
                    Effect = Effect.Positive,
                    Description = "100 грамм зелья омоложает выпившего на 20 лет. Если ему меньше лет, он превращается в новорожденного.",
                },
                new PotionsInformationClass()
                {
                    PotionID = 4,
                    Title = "Зелье Вампиризма",
                    Effect = Effect.Negative,
                    Description = "Превращает выпившего в вампира."
                },
                new PotionsInformationClass()
                {
                    PotionID = 5,
                    Title = "Зелье Удачи",
                    Effect = Effect.Positive,
                    Description = "Выпивший становится удачливым на 24 часа."
                },
                new PotionsInformationClass()
                {
                    PotionID = 6,
                    Title = "Зелье Ясновидения",
                    Effect = Effect.Neutral,
                    Description = "Выпивший повышает свои способности к ясновидению. Если он не проведет обряд гадания, ему приснится сон, который поведает ему о будущем."
                },
                new PotionsInformationClass()
                {
                    PotionID = 7,
                    Title = "Вредное Зелье",
                    Effect = Effect.Negative,
                    Description = "Выпивший покрывается бородавками. Если не пытаться свести их никакими средствами, они проходят через 29 дней."
                },
                new PotionsInformationClass()
                {
                    PotionID = 8,
                    Title = "Противозельевое Зелье",
                    Effect = Effect.Positive,
                    Description = "Устраняет эффект любого зелья (кроме тех, которые по природе своей не могут быть устранены таким образом)."
                },
                new PotionsInformationClass()
                {
                    PotionID = 9,
                    Title = "Сырное зелье",
                    Effect = Effect.Neutral,
                    Description = "Выпивший это зелье превращается в сыр."
                }
            };

            return potions;
        }
    }
}