export default {
    content: [
        "./index.html",
        "./src/**/*.{vue,js,ts,jsx,tsx}",
    ],
    theme: {
        extend: {
            colors: {
                "guest-view-primary": '#ffc017'
            },
            fontFamily: {
                'times': ['Times New Roman', 'serif'],
            }
        },
    },
    plugins: [],
}