// using System.Collections;
//
// namespace Shared.Extensions;
//
// public static class LinqExtensions
// {
//     public static IEnumerable<TInterface> OfInterfaceType<TInterface>(this IEnumerable source)
//     {
//         return OfInterfaceTypeIterator<TInterface>(source);
//     }
//
//     private static IEnumerable<TInterface> OfInterfaceTypeIterator<TInterface>(this IEnumerable source)
//     {
//         foreach (var value in source)
//         {
//             var type = value.GetType();
//             var test = value.GetType().InheritsOrImplements(typeof(TInterface));
//             if (value.GetType().InheritsOrImplements(typeof(TInterface)))
//                 yield return (TInterface)value;
//         }
//         // return source.Cast<object>().Where(obj => obj.GetType().InheritsOrImplements(typeof(TInterface))).Cast<TInterface>();
//     }
// }