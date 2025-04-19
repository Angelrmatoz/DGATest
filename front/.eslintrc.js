/* eslint-env node */
module.exports = {
    root: true,
    'extends': [
        'plugin:vue/vue3-essential',
        'eslint:recommended',
        '@vue/eslint-config-typescript'
    ],
    parserOptions: {
        ecmaVersion: 'latest'
    },
    // Patrones de archivos a ignorar
    ignorePatterns: [
        '**/*.vue.js',
        '**/*.vue.d.ts',
        '**/*.js.map',
        'dist/**/*',
        'node_modules/**/*'
    ],
    rules: {
        // Desactivar reglas problemáticas
        '@typescript-eslint/no-unused-expressions': 'off',
        'no-unused-expressions': 'off'
    }
} 