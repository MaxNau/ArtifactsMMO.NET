namespace ArtifactsMMO.NET.Validators
{
    internal interface IValidator<in T>
    {
        void Validate(T value);
    }
}
