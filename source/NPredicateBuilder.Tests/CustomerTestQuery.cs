﻿namespace NPredicateBuilder.Tests
{
    public class CustomerTestQuery : BaseQuery<Customer>
    {
        public CustomerTestQuery AndNameIsBobby()
        {
            AddAndCriteria(x => x.Name == "Bobby");

            return this;
        }

        public CustomerTestQuery AndNameIsBilly()
        {
            AddAndCriteria(x => x.Name == "Billy");

            return this;
        }

        public CustomerTestQuery AndAgeIsOverSix()
        {
            AddAndCriteria(x => x.Age >= 6);

            return this;
        }

        public CustomerTestQuery OrAgeIsOverTwenty()
        {
            AddOrCriteria(x => x.Age >= 20);

            return this;
        }
    }
}