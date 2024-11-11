namespace MinimalAPI.Services
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Adds two integers and returns the result.
        /// </summary>
        /// <param name="x">The first integer to add.</param>
        /// <param name="y">The second integer to add.</param>
        /// <returns>The sum of the two integers.</returns>
        int add(int x, int y);

    }
}
