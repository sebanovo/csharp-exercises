# Letra T en 3D con OpenTK

Este proyecto es una aplicación de OpenGL usando OpenTK para renderizar una letra "T" en 3D. La letra "T" se dibuja utilizando un shader simple y se renderiza en una ventana con OpenTK.

<img src='https://i.postimg.cc/DZ2sgQjK/image.png' border='0' alt='image'/>

## Estructura del Proyecto

- `Game.cs`: Contiene la clase principal del juego que configura la ventana, carga los shaders, y dibuja la letra "T".
- `shader.frag`: Archivo de shader de fragmento que define el color de los fragmentos.
- `shader.ver`: Archivo de shader de vértice que define la transformación de los vértices.

## Dependencias

- OpenTK: Biblioteca para trabajar con OpenGL y manejar la ventana.

## Cómo Ejecutar el Proyecto

1. Asegúrate de tener las dependencias instaladas.
2. Compila y ejecuta el proyecto.

## Archivos de Shader

- **`shader.ver`** (Shader de Vértice):

    ```glsl
    #version 330 core
    layout (location = 0) in vec3 aPosition;
    void main()
    {
        gl_Position = vec4(aPosition, 1.0);
    }
    ```

- **`shader.frag`** (Shader de Fragmento):

    ```glsl
    #version 330 core
    out vec4 FragColor;
    void main()
    {
        FragColor = vec4(1.0, 0.5, 0.2, 1.0);
    }
    ```

## Recursos

- **Color de fondo**: Definido en `GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);`.
- **Letra "T"**: Representada usando un conjunto de vértices y un índice para dibujar dos triángulos que forman la letra "T".

## Notas

- El proyecto configura OpenGL, carga los shaders desde archivos externos y dibuja la letra "T" usando buffers de vértices y elementos.
- Los recursos se liberan correctamente al finalizar la aplicación.