/** @type {import('tailwindcss').Config} */

// npx tailwindcss -i .\Styles\app.css -o .\wwwroot\css\app.css --watch

module.exports = {
    darkMode: 'class',
    mode: "jit",
    content: [
        './**/**/*.razor',
        './**/index.html'
    ],
    theme: {
        extend: {}
    },
    plugins: [],
}

