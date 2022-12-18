import React, { Fragment } from 'react';
import { Reply } from '../../app/models/reply';
import ReplyBody from './ReplyBody';

interface Props {
    reply: Reply
}

function ReplyListItem({ reply }: Props) {
    return (
        <Fragment>
            <tr>
                <td>
                    <ReplyBody reply={reply} />
                </td>
            </tr>
        </Fragment>
    );
}

export default ReplyListItem;