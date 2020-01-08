using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace BaseDrawIoPlugin.Extensions
{
    public static class ExpressionExtensions
    {
        public static string GetMethodName<T>(Expression<Func<T, Action>> expression)
        {
            var unaryExpression = (UnaryExpression)expression.Body;
            var methodCallExpression = (MethodCallExpression)unaryExpression.Operand;
            return ((MemberInfo)((ConstantExpression)methodCallExpression.Object).Value).Name;
        }
    }
}
