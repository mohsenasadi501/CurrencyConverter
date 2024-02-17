module.exports = {
    preset: 'ts-jest',
    testEnvironment: 'jsdom',
    moduleNameMapper: {
        '\\.(css|less|scss|sass)$': 'identity-obj-proxy', // For handling CSS imports
    },
    setupFilesAfterEnv: ['<rootDir>/src/setupTests.ts'], // Optional: Setup file for Jest
};
