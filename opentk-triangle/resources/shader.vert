#version 330 core
// GLSL
layout (location = 0) in vec3 aPosition;
layout (location = 1) in vec3 ourColor;
layout (location = 2) in vec2 aTexCoord;

out vec3 color;
out vec2 TexCoord;
uniform float xOffSet;

void main()
{
    gl_Position = vec4(aPosition.x + xOffSet, aPosition.y + xOffSet, aPosition.z + xOffSet, 1.0);
    color = ourColor;
    TexCoord = aTexCoord;
}
