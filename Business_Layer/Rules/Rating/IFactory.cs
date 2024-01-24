namespace Business_Layer.Rules.Rating
{
    internal interface IFactory<T>
    {
        T Evaluate(T value);
    }
}