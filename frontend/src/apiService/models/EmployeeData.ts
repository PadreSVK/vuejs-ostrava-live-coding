/* istanbul ignore file */
/* tslint:disable */
/* eslint-disable */

import type { PositionEnum } from './PositionEnum';

export type EmployeeData = {
    id?: number;
    firstName?: string | null;
    lastName?: string | null;
    prefix?: string | null;
    position?: PositionEnum;
    picture?: string | null;
    birthDate?: string;
    hireDate?: string;
    emailAddress?: string | null;
    phoneNumber?: string | null;
    notes?: string | null;
    address?: string | null;
    state?: string | null;
    city?: string | null;
}