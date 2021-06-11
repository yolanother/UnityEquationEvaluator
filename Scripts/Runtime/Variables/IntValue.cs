using System;
using DoubTech.EquationEvaluator;
using UnityEngine;

namespace DoubTech.EquationEvaluator.Variables
{
    [CreateAssetMenu(fileName="IntVariable", menuName="Equation Evaluator/Variables/Int")]
    public class IntValue : ScriptableObject
    {
        public int value;
    }

    [Serializable]
    public class IntVariable
    {
        public bool useConstant;
        public int constant;
        public IntValue variable;

        public int Value => useConstant ? constant : variable.value;
    }
}
