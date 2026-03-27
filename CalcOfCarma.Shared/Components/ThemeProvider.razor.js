export function getSystemTheme() {
    return window.matchMedia("(prefers-color-scheme: dark)").matches ? 'dark' : 'light';
}

export function saveTheme(theme) {
    localStorage.setItem('user-theme', theme);
}

export function getSavedTheme() {
    return localStorage.getItem('user-theme');
}