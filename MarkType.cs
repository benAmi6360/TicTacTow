namespace TicTacTow
{
    /// <summary>
    /// The type of value a cell in the game is currently at
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// The Cell hasn't been clicked yet
        /// </summary>
        Free = 0,
        /// <summary>
        /// The cell is a O
        /// </summary>
        Nought,
        /// <summary>
        /// The cell is an X
        /// </summary>
        Cross,
    }
}
