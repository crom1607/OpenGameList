/**
 * @license
 * Copyright Google Inc. All Rights Reserved.
 *
 * Use of this source code is governed by an MIT-style license that can be
 * found in the LICENSE file at https://angular.io/license
 */
import { PipeTransform } from '@angular/core';
/**
 *
 *  Generic selector that displays the string that matches the current value.
 *
 *  ## Usage
 *
 *  expression | i18nSelect:mapping
 *
 *  where `mapping` is an object that indicates the text that should be displayed
 *  for different values of the provided `expression`.
 *
 *  ## Example
 *
 *  ```
 *  <div>
 *    {{ gender | i18nSelect: inviteMap }}
 *  </div>
 *
 *  class MyApp {
 *    gender: string = 'male';
 *    inviteMap: any = {
 *      'male': 'Invite him.',
 *      'female': 'Invite her.',
 *      'other': 'Invite them.'
 *    }
 *    ...
 *  }
 *  ```
 *
 *  @experimental
 */
export declare class I18nSelectPipe implements PipeTransform {
    transform(value: string, mapping: {
        [key: string]: string;
    }): string;
}
