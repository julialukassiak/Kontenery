namespace Kontenery;

using System;
public class PrzekroczeniePojemnosciWyjatek : Exception
{
    public PrzekroczeniePojemnosciWyjatek(string message) : base(message) { }
}
