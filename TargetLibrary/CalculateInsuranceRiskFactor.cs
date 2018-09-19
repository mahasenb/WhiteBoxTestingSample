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
            switch (gender)
            {
                case Gender.Female:
                    return 0.01f;
                case Gender.Male:
                default:
                    return 0.02f;
            }
        }

        private static float GetAgeMultiplier(AgeGroup ageGroup)
        {
            switch (ageGroup)
            {
                case AgeGroup.LessThanTwenty:
                    return 0.01f;
                case AgeGroup.TwentyOneToForty:
                    return 0.03f;
                case AgeGroup.FortyOneToSixty:
                    return 0.05f;
                case AgeGroup.AboveSixty:
                default:
                    return 0.08f;
            }
        }

        private static float GetProvinceMultiplier(Province province)
        {
            switch (province)
            {
                case Province.Central:
                case Province.Western:
                case Province.Southern:
                    return 0.01f;

                case Province.Sabaragamuwa:
                case Province.Uva:
                case Province.NorthCentral:
                case Province.NorthWestern:
                    return 0.02f;

                case Province.Eastern:
                case Province.Northern:
                default:
                    return 0.03f;
            }
        }
    }
}
