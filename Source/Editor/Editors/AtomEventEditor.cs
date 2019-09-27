#if UNITY_2019_1_OR_NEWER
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

namespace UnityAtoms.Editor
{
    public abstract class AtomEventEditor<T, E> : UnityEditor.Editor
        where E : AtomEvent<T>
    {
        protected T _raiseValue = default(T);

        protected virtual VisualElement GetRaiseValueInput() { return null; }

        public override VisualElement CreateInspectorGUI()
        {
            var wrapper = new VisualElement();
            wrapper.SetEnabled(Application.isPlaying);

            var input = GetRaiseValueInput();
            if (input != null)
            {
                wrapper.Add(input);
            }

            wrapper.Add(new Button(() =>
            {
                E e = target as E;
                e.Raise(_raiseValue);
            })
            {
                text = "Raise"
            });

            return wrapper;
        }
    }

    [CustomEditor(typeof(BoolEvent))]
    public sealed class BoolEventEditor : AtomEventEditor<bool, BoolEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new Toggle() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<bool>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(ColliderEvent))]
    public sealed class ColliderEventEventEditor : AtomEventEditor<Collider, ColliderEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new ObjectField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value", objectType = typeof(Collider) };
            input.RegisterCallback<ChangeEvent<Collider>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(Collider2DEvent))]
    public sealed class Collider2DEventEditor : AtomEventEditor<Collider2D, Collider2DEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new ObjectField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value", objectType = typeof(Collider2D) };
            input.RegisterCallback<ChangeEvent<Collider2D>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(ColorEvent))]
    public sealed class ColorEventEditor : AtomEventEditor<Color, ColorEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new ColorField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<Color>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(FloatEvent))]
    public sealed class FloatEventEditor : AtomEventEditor<float, FloatEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new FloatField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<float>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(GameObjectEvent))]
    public sealed class GameObjectEventEditor : AtomEventEditor<GameObject, GameObjectEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new ObjectField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value", objectType = typeof(GameObject) };
            input.RegisterCallback<ChangeEvent<GameObject>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(IntEvent))]
    public sealed class IntEventEditor : AtomEventEditor<int, IntEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new IntegerField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<int>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(Vector2Event))]
    public sealed class Vector2EventEditor : AtomEventEditor<Vector2, Vector2Event>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new Vector2Field() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<Vector2>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(Vector3Event))]
    public sealed class Vector3EventEditor : AtomEventEditor<Vector3, Vector3Event>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new Vector3Field() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<Vector3>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }

    [CustomEditor(typeof(VoidEvent))]
    public sealed class VoidEventEditor : AtomEventEditor<Void, VoidEvent> { }

    [CustomEditor(typeof(StringEvent))]
    public sealed class StringEventEditor : AtomEventEditor<string, StringEvent>
    {
        protected override VisualElement GetRaiseValueInput()
        {
            var input = new TextField() { label = "Raise value", name = "Raise value", viewDataKey = "Raise value" };
            input.RegisterCallback<ChangeEvent<string>>((evt) => { _raiseValue = evt.newValue; });
            return input;
        }
    }
}
#endif
