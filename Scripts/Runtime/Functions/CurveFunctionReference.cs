using UnityEngine;

namespace DoubTech.EquationEvaluator.Functions
{
    [CreateAssetMenu(fileName = "CurveFunctionReference",
        menuName = "Equation Evaluator/Functions/Curve")]
    public class CurveFunctionReference : FunctionReference
    {
        [SerializeField] private AnimationCurve curve;
        public override double Evaluate(double[] arguments)
        {
            return curve.Evaluate((float) arguments[0]);
        }
    }
}
