namespace TargetLibrary
{
    public class CalculateInsuranceRiskFactor
    {
        public decimal GetRiskFactor(InsuranceRiskInformation riskInformation)
        {
            return GetGenderMultiplier(riskInformation.Gender)
                   + GetAgeMultiplier(riskInformation.AgeGroup)
                   + GetProvinceMultiplier(riskInformation.Province);
        }

        private decimal GetGenderMultiplier(Gender gender)
        {
            decimal factor;

            switch (gender)
            {
                case Gender.Male:
                    factor = 0.01m;
                    break;
                case Gender.Female:
                default:
                    factor = 0.02m;
                    break;
            }

            return factor;
        }

        private decimal GetAgeMultiplier(AgeGroup ageGroup)
        {
            decimal factor;

            switch (ageGroup)
            {
                case AgeGroup.LessThanTwenty:
                    factor = 0.01m;
                    break;
                case AgeGroup.TwentyOneToForty:
                    factor = 0.03m;
                    break;
                case AgeGroup.FortyOneToSixty:
                    factor = 0.05m;
                    break;
                case AgeGroup.AboveSixty:
                default:
                    factor = 0.08m;
                    break;
            }

            return factor;
        }

        private decimal GetProvinceMultiplier(Province province)
        {
            decimal factor;

            switch (province)
            {
                case Province.Central:
                case Province.Western:
                case Province.Southern:
                    factor = 0.01m;
                    break;

                case Province.Sabaragamuwa:
                case Province.Uva:
                case Province.NorthCentral:
                case Province.NorthWestern:
                    factor = 0.02m;
                    break;

                case Province.Eastern:
                case Province.Northern:
                default:
                    factor = 0.03m;
                    break;
            }

            return factor;
        }
    }
}
