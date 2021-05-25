
export function isDevelopment(): boolean {
    return process.env.NODE_ENV === "development"
}

export const configuration = {
    baseUrl: process.env.VUE_APP_BASE_URL,
    ...(isDevelopment() && {
        develop: {
            credentials: {
                email: process.env.VUE_APP_DEFAULT_USER_EMAIL,
                password: process.env.VUE_APP_DEFAULT_USER_PASWWORD,
            }
        }
    })
}