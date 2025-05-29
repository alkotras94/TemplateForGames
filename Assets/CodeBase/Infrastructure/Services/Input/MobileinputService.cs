using UnityEngine;

namespace Assets.CodeBase.Infrastructure.Services.Input
{
    public class MobileinputService : InputService
    {
        public override Vector2 Axis => SimpleInputAxis();
    }
}