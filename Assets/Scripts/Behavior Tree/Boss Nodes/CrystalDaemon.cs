using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//checks if Crystal is being attacked

namespace BTArchitecture {
    public class CrystalDaemon : Node
    {
        public CrystalDaemon() : base() { }

        public CrystalDaemon(List<Node> children) : base(children) { }

        public override NodeState Evaluate() {
            List<Crystal> crystals = (List<Crystal>) this.GetData("crystals");
            bool damaged = false;
            foreach (Crystal c in crystals) {
                if(c.WasDamaged())
                {
                    damaged = true;
                    break;
                }
            }
            if (!damaged){
			    return NodeState.FAILURE;
            } else {
			    return children[0].Evaluate();
            }
        }
    }
}
