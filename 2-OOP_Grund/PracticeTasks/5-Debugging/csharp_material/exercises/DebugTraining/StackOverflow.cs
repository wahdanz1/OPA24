namespace DebugExample
{
    // Stack overflow is not just one of the best websites there is for a coder, it is also a concept in programming
    // 1) Read about the concept, then try this code out.
    // 2) Test to run this code with a debugger. What do you see?
    // 3) Try to understand what recursion does and why this gives an error.
    // 4) Somewhere else in this code, there is another recursion hidden.
    //      This is wrong and gives an ugly call stack, even tough it does work. Find it.

    // We have two different kinds of recursions.
    // Direct Recursion - A method is calling itself
    // Indirect Recursion - Method A calls method B, which in turn calls method A (loops between method A and method B)
    //
    // When a recursion happens and no value is returned, a frame is added to the stack.
    // For every recursion, another frame is added to the stack.
    // Eventually, the stack reaches its limit and a "stack overflow" happens.
    // A stack overflow is when a new frame is trying to be added to an already full stack, 
    // and a fram in the stack is being "pushed" out of the stack.

    public class StackOverFlow
    {
        public static int X(int value)
        {
            int y = Y(value);
            return y;
        }
        private static int Y(int value)
        {
            int x = X(value*value);
            return x;
        }
    }
}