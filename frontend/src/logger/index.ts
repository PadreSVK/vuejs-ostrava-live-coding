
import store from "@/store";
const storage = window.localStorage
const logLevel = () => ((store.state as any).administration as AdministrationState).logLevel

export function dumpLogs() {
    const value = localStorage.getItem("logs") || "[]"
    return JSON.parse(value);
}

export function tryGetLogLevel(){
    const logLevel = localStorage.getItem("logLevel")
    if(logLevel){
        return logLevel as LogLevel
    }
    return undefined
}
export function changeLogLevel(logLevel : LogLevel){
    localStorage.setItem("logLevel", logLevel)
}



function log(level: LogLevel, message: string) {
    const date = new Date().toString()
    const logsJson = storage.getItem("logs")
    const log = [`${date} |=| ${level} |=| ${message}`]
    if (logsJson) {
        const logs = JSON.parse(logsJson as string) as Array<string>
        logs.push(log[0])
        storage.setItem("logs", JSON.stringify(logs))
    }
    else {
        storage.setItem("logs", JSON.stringify(log))
    }
}

export function logError(message: string) {
    log("Error", message)
}
export function logWarning(message: string) {
    if (logLevel() == "Information" || logLevel() == "Warning") {
        log("Warning", message)

    }
}
export function logInformation(message: string) {
    if (logLevel() == "Information") {
        log("Information", message)
    }
}
