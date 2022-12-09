using System.Collections.Generic;

namespace ALevelSample.Model;

public class CollectionData<T> : Validation
{
    public IReadOnlyCollection<T>? Data { get; init; }
}