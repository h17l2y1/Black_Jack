import { PlayerGameView } from './playerGameView';

export class ResponseStartGameView {
    gameId: string;
    bots: Array<PlayerGameView>;
    user: PlayerGameView;
    cardsleft: number;
}
