namespace TargetLibrary
{
    public class CalculateInsuranceRiskFactor
    {
        public static float GetRiskFactor(InsuranceRiskInformation riskInformation)
        {
            return GetGenderMultiplier(riskInformation.Gender)
                   + GetAgeMultiplier(riskInformation.AgeGroup)
                   + GetProvinceMultiplier(riskInformation.Province);
        }

        private static float GetGenderMultiplier(Gender gender)
        {
            float factor;

            switch (gender)
            {
                case Gender.Female:
                    factor = 0.01f;
                    break;
                case Gender.Male:
                default:
                    factor = 0.02f;
                    break;
            }

            return factor;
        }

        private static float GetAgeMultiplier(AgeGroup ageGroup)
        {
            float factor;

            switch (ageGroup)
            {
                case AgeGroup.LessThanTwenty:
                    factor = 0.01f;
                    break;
                case AgeGroup.TwentyOneToForty:
                    factor = 0.03f;
                    break;
                case AgeGroup.FortyOneToSixty:
                    factor = 0.05f;
                    break;
                case AgeGroup.AboveSixty:
                default:
                    factor = 0.08f;
                    break;
            }

            return factor;
        }

        private static float GetProvinceMultiplier(Province province)
        {
            float factor;

            switch (province)
            {
                case Province.Central:
                case Province.Western:
                case Province.Southern:
                    factor = 0.01f;
                    break;

                case Province.Sabaragamuwa:
                case Province.Uva:
                case Province.NorthCentral:
                case Province.NorthWestern:
                    factor = 0.02f;
                    break;

                case Province.Eastern:
                case Province.Northern:
                default:
                    factor = 0.03f;
                    break;
            }

            return factor;
        }
    }
}
