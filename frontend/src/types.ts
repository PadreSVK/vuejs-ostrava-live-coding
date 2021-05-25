type LogLevel = "Information" | "Warning" | "Error"

type IdenityState = {
    userInfo: UserInfo
}

type AdministrationState = {
    logLevel: LogLevel
}

type UserInfo = {
    id: string
    sub: string
    email: string
    jti: string
}

