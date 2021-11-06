using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Engine {
    public class ShaderList {

        Dictionary<string, Effect> shaders = new Dictionary<string, Effect>();


        public ShaderList(Dictionary<string, Effect> shadersLoad) {

            shaders = shadersLoad;
        }


        public Effect GetShader(string shaderName) {

            return shaders[shaderName];
        }
    }
}