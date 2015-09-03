﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShipPrototype.Components
{
    class ParticleController : ControllerComponent
    {
        float life_;
        public float fadeSpeed = 0;
        public float opacity = 1;
        public ParticleController(GameEntity entity, float life) : base(entity)
        {
            life_ = life;
        }

        public override void update(float elapsed)
        {
            if (fadeSpeed > 0)
            {
                opacity -= fadeSpeed * elapsed;
                entity_.render.color_ = new Microsoft.Xna.Framework.Color(1f, 1f, 1f, opacity);
            }
            life_ -= elapsed;
            if (life_ <= 0 || opacity <= 0)
            {
                Locator.getComponentManager().removeEntity(entity_);
            }
        }
    }
}
