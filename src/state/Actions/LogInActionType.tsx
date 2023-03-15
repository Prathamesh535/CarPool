interface LogInName {
    type: string,
    payload: string
}
interface LogInPassword {
    type: string,
    payload: string
}
export type LogInActionType = LogInName | LogInPassword