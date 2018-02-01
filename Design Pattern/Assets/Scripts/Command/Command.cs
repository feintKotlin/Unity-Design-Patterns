using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Feint.Command
{

    public interface Command
    {
        Command Execute();

        Command Undo();

        Command Redo();

    }

}
