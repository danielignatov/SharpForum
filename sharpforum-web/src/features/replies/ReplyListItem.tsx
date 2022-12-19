import Container from 'react-bootstrap/Container';
import { Reply } from '../../app/models/reply';
import ReplyBody from './ReplyBody';

interface Props {
    reply: Reply
}

function ReplyListItem({ reply }: Props) {
    return (
        <Container className='sf-header'>
            <ReplyBody reply={reply} />
        </Container>
    );
}

export default ReplyListItem;