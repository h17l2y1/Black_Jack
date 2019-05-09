import { PlayerGameView } from './playerGameView';
import { ResponseWinnerGameView } from './responseWinnerGameView';

export class ResponseStopGameView {
    gameId: string;
    bots: Array<PlayerGameView>;
    user: PlayerGameView;
    cardsleft: number;
    winner: ResponseWinnerGameView;
}
