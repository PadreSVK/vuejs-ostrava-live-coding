type LogLevel = "Information" | "Warning" | "Error"

type IdenityState = {
    userInfo: UserInfo
}

type AdministrationState = {
    logLevel: LogLevel,
    logs: Array<Log>
}

type UserInfo = {
    id: string
    sub: string
    email: string
    jti: string
}

type Log = {
    date: string
    level: string
    message: string
}