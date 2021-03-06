type LogLevel = "Information" | "Warning" | "Error"

type GlobalState = {

}

type IdenityState = {
    userInfo: UserInfo
}

type GraphState = {
    graphData: Array<Number>
}

type NotificationState = {
    showError: boolean,
    errorMessage: string,
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