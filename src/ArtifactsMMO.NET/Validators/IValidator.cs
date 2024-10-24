namespace ArtifactsMMO.NET.Validators
{
    internal interface IValidator<T>
    {
        void Validate(T value);
    }
}
