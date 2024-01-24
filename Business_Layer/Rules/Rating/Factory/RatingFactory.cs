namespace Business_Layer.Rules.Rating.Factory
{
    using Data.Entities;

    internal class RatingFactory : IFactory<Proposal>
    {
        public Proposal Evaluate(Proposal proposal)
        {
            Rating rating = SomeBusinessRule(proposal);

            proposal.Rating = rating;

            return proposal;
        }

        private static Rating SomeBusinessRule(Proposal proposal)
        {
            var rating = new Rating();

            if (proposal.Client.ToLower().Contains("test"))
            { 
                rating.Rate = new RateTypes("Medium");
            }
            return rating;
        }
    }
}
